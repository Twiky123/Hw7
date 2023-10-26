using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dz7_;
namespace Dz7_
{
    
    class Task
    {
        #region Поля
        private string taskContent;
        private WorkingDepartments taskAddress;
        #endregion

        #region Свойства

        public string TaskContent
        {
            get
            {
                return taskContent;
            }
        }

        public WorkingDepartments TaskAddress
        {
            get
            {
                return taskAddress;
            }
        }
        #endregion

        #region Конструкторы

        public Task(string taskContent, WorkingDepartments taskAddress)
        {
            this.taskContent = taskContent;
            this.taskAddress = taskAddress;
        }
        #endregion
    }
}

