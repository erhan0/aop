using System;
using System.Collections.Generic;
using SheepAspect.Aspects;
using SheepAspect.Framework;
using SheepAspect.Runtime;
using SmartTransactionDemo.DataAccess;

namespace SmartTransactionDemo.Aspects
{
    [AspectPerCFlow("TargetMembers")]
    public class TransactionAttribute: OnMemberBoundaryAttribute
    {
        [SelectMethods("HasCustomAttributeType: 'SmartTransactionDemo.Aspects.NonTransactionalAttribute' & ReturnsVoid")]
        private void NonTransactionalMethods() { }

        private readonly Queue<Action> _nonTransactionalActions = new Queue<Action>();

        [Around("NonTransactionalMethods")]
        public void StealNonTransactionalMethods(IJointPoint jp)
        {
            _nonTransactionalActions.Enqueue(() => jp.Execute());
        }

        public override object Around(IMemberJointPoint jp)
        {
            using (var tx = DataStore.BeginTransaction())
            {
                var returnValue = jp.Execute();
                tx.Commit();

                foreach (var action in _nonTransactionalActions)
                    action();
                return returnValue;
            }
        }
    }

}