using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AttendanceRecord.Infrastructure.Extantions
{   
    public static class ServiceInjectionExtensions
        {
        public static void  AddServices(this IServiceCollection services , Assembly assembly)
        {
            var types = assembly.GetTypes().Where(t => t.Name.EndsWith("Service"));


            foreach (var impl in types)
            {
                var interfaceType = impl.GetInterfaces().FirstOrDefault(i => i.Name == $"I{impl.Name}");
                if (interfaceType == null)
                {
                    services.AddScoped(interfaceType, impl);

                }

            }
                

        }
    }
}
