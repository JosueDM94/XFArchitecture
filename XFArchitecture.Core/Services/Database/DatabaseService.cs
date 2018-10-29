using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using XFArchitecture.Core.Models;
using XFArchitecture.Core.Contracts.Database;
using XFArchitecture.Core.Services.Database.Consumer;

namespace XFArchitecture.Core.Services.Database
{
    public class DatabaseService : IDatabaseService
    {
        protected UserConsumer userConsumer;
        protected GradeConsumer gradeConsumer;
        protected CourseConsumer courseConsumer;
        protected CourseUserConsumer courseUserConsumer;
        protected AttendanceConsumer attendanceConsumer;
        protected EnrollmentConsumer enrollmentConsumer;

        public DatabaseService()
        {
            userConsumer = new UserConsumer();
            gradeConsumer = new GradeConsumer();
            courseConsumer = new CourseConsumer();
            courseUserConsumer = new CourseUserConsumer();
            attendanceConsumer = new AttendanceConsumer();
            enrollmentConsumer = new EnrollmentConsumer();
        }

        public async Task<bool> InsertUser(User user) => await userConsumer.InserUser(user);

        public async Task<bool> DeleteUser(User user) => await userConsumer.DeleteUser(user);

        public async Task<bool> UpdateUser(User user) => await userConsumer.UpdateUser(user);

        public Task<List<User>> Select() => userConsumer.GetUsers();
    }
}