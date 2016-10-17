using KnxProject_Franco.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using KnxProject_Franco.CONTRACTS.Entities;
using AutoMapper;

namespace KnxProject_Franco
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<myContext>());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            App_Start.UnityWebActivator.Start();
            ModelBinders.Binders.Add(typeof(PersonModel), new PersonModelBinder());

        }

        public class PersonModelBinder : DefaultModelBinder
        {

            protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
            {
                    PersonType personType = GetValue<PersonType>(bindingContext, "PersonType");

                Type model = PersonModel.SelectFor(personType);

                PersonModel instance = (PersonModel)base.CreateModel(controllerContext, bindingContext, model);

                bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => instance, model);

                return instance;
            }

            private PersonType GetValue<T>(ModelBindingContext bindingContext, string key)
            {
                ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(key);
                

                bindingContext.ModelState.SetModelValue(key, valueResult);

                switch (valueResult.AttemptedValue)
                {
                    case "Lawyer":
                        return PersonType.Lawyer;
                    case "Client":
                        return PersonType.Client;
                    case "Employee":
                        return PersonType.Employee;
                    default:
                        return PersonType.Client;
                }
                //return (T)valueResult.ConvertTo(typeof(T));
            }
        }
    }
}

