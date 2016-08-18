using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using WorldsNomad.Logic.Processor;

namespace WorldsNomad.Logic
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<SequenceGenerator>().As<ISequenceGenerator>();
        }
    }
}
