using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using SheepAspect.Exceptions;
using System.Xml.XPath;
using System.Linq;

namespace SheepAspect.Compile
{
    public class XmlCompilerSettings: CompilerSettings
    {
        private const string ConfigXsd = "SheepAspect.SheepAspectConfig.xsd";
        private const string Namespace = "urn:sheepaspect-config-1.0";

        public XmlCompilerSettings(string file)
        {
            var doc = XDocument.Load(file);

            doc.Validate(ReadXmlSchemaFromEmbeddedResource(ConfigXsd), (o, e) =>
                { throw new SheepAspectConfigException("An exception occured parsing configuration: " + e.Message, e.Exception); }
            );

            var ns = new XmlNamespaceManager(new NameTable());
            ns.AddNamespace("t", Namespace);
            var root = doc.Root;

            BaseDirectory = Path.GetDirectoryName(file);

            foreach (var str in GetFiles(root.XPathSelectElement("t:aspects/t:assemblies", ns), ns))
                AspectAssemblyFiles.Add(str);

            foreach (var str in GetFiles(root.XPathSelectElement("t:weave/t:assemblies", ns), ns))
                TargetAssemblyFiles.Add(str);
        }

        private IEnumerable<string> GetFiles(XNode assemblies, XmlNamespaceManager ns)
        {
            var files = assemblies.XPathSelectElements("t:include", ns).Select(d => d.Value);

            var dirFiles = assemblies.XPathSelectElements("t:directory", ns)
                .SelectMany(d => d.XPathSelectElements("t:include", ns).Select(e => GetPath(d.Attribute("path").Value, e.Value)));

            return files.Union(dirFiles);
        }

        private string GetPath(string dir, string pattern)
        {
            return Path.Combine(dir, pattern);
        }


    private static XmlSchemaSet ReadXmlSchemaFromEmbeddedResource(string resourceName)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();

            using (var resourceStream = executingAssembly.GetManifestResourceStream(resourceName))
            {
                var xmlSchema = XmlSchema.Read(resourceStream, null);
                var xmlSchemaSet = new XmlSchemaSet();
                xmlSchemaSet.Add(xmlSchema);
                xmlSchemaSet.Compile();
                return xmlSchemaSet;
            }
        }
    }
}