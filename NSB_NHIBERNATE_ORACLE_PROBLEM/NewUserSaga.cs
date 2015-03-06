using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus.Saga;

namespace NSB_NHIBERNATE_ORACLE_PROBLEM
{
    public class NewUserSagaData : ContainSagaData
    {
        [Unique]
        public virtual string Name { get; set; }
    }

    public class NewUserSaga : Saga<NewUserSagaData>, IAmStartedByMessages<NewUser>, IHandleTimeouts<NewUserSagaTimeout>
    {
        public void Handle(NewUser message)
        {
            RequestTimeout<NewUserSagaTimeout>(DateTime.SpecifyKind(DateTime.Now.AddSeconds(10), DateTimeKind.Local));
        }

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<NewUserSagaData> mapper)
        {

        }

        public void Timeout(NewUserSagaTimeout state)
        {
           
        }
    }
}
