using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace AttendanceRecord.Infrastructure.Extantions
{
    public static class DependencyInjectionExtensions
    {
        public static void AddRepositories(this IServiceCollection service , Assembly assembly )
        {


            var Types = assembly.GetTypes().Where(t => t.Name.EndsWith("Repository") && t.IsClass);

            foreach (var impl in Types)
            {
                var interfaceType = impl.GetInterfaces().FirstOrDefault(t => t.Name == $"I{impl.Name}");

                if (interfaceType !=null)
                {
                    service.AddScoped (interfaceType, impl);

                }

            }
        }
    }
}
