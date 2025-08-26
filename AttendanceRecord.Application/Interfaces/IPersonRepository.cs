using AttendanceRecord.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AttendanceRecord.Application.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person> GetByIdAsync(int id);
        Task<IEnumerable<Person>> GetAllAsync();
        void Add(Person person); // برای اضافه کردن به context
        void Update(Person person); // برای ویرایش
        void Delete(Person person); // برای حذف
        Task<int> SaveChangesAsync(); // برای ذخیره تمام تغییرات
    }
}