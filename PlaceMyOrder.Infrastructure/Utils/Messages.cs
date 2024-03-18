using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceMyOrder.Infrastructure.Utils
{
    public static class Messages
    {
        // ERRORS
        public static String InternalServerError = "error.message.internalServerError";
        public static String UserAlreadyExists = "error.message.userAlreadyExists";
        public static String LoginFailed = "error.message.loginFailed";
        public static String Unauthorized = "error.message.unauthorized";
        public static String MealNotFoundOrderCreation = "error.message.mealNotFoundOrderCreation";


        // SUCCESS
        public static String UserRegistered = "success.message.userCreated";


    }
}
