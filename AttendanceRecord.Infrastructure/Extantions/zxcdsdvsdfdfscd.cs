using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.Extensions.Options;

namespace AttendanceRecord.Infrastructure.Extantions
{
    public static class zxcdsdvsdfdfscd
    {
        public static void AddServices(this IServiceCollection services, Assembly assembly)
        {
            var Types = assembly.GetTypes().Where(t => t.Name.EndsWith("Service"));

            foreach (var Impl in Types)
            {
                var InterfaceType = Impl.GetInterfaces().FirstOrDefault(i => i.Name == $"I{Impl.Name}");

                if (InterfaceType == null)
                {
                    services.AddScoped(InterfaceType, Impl);
                }
            }


        }

    }
}
