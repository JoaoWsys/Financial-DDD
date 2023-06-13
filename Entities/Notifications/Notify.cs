using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Notifications
{
    public class Notify
    {

        public Notify()
        {
            Notifications = new List<Notify>();
        }

        [NotMapped]
        public string PropertyName { get; set; }

        [NotMapped]
        public string Message { get; set; }

        [NotMapped]
        public List<Notify> Notifications { get; set; }

        public bool StringPropertyValidate(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(propertyName))
            {
                Notifications.Add(new Notify
                {
                    Message = "Required Field",
                    PropertyName = propertyName,
                });
                return false;
            }

            return true;
        }

        public bool IntPropertyValidate(int value, string propertyName)
        {
            if (value < 1 || string.IsNullOrWhiteSpace(propertyName))
            {
                Notifications.Add(new Notify
                {
                    Message = "Required Field",
                    PropertyName = propertyName,
                });
                return false;
            }

            return true;
        }


    }
}
