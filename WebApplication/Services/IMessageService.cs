using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Services {
    public interface IMessageService {
        void Send(string message);
    }

    public class Mailer : IMessageService {
        public void Send(String message) {
            Debug.WriteLine("Mailer: " + message);
        }
    }

    public class SmsSender : IMessageService {
        public void Send(String message) {
            Debug.WriteLine("SMS: "  + message);
        }
    }
}
