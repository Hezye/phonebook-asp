using Autofac;
using Phonebook.Core;
using Phonebook.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Application.DependencyInjection
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PhoneEntryRepository>().As<IPhoneEntryRepository>();
            builder.RegisterType<PhonebookManager>().As<IPhonebookManager>();
        }
    }
}
