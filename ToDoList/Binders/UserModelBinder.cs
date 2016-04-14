using System.Web.Mvc;
using ToDoList.Models;

namespace ToDoList.Binders
{
    public class UserModelBinder : IModelBinder
    {
        private const string sessionKey = "user";

        public object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            // Получить объект UserModel из сеанса
            UserModel userModel = null;
            if (controllerContext.HttpContext.Session != null)
            {
                userModel = (UserModel)controllerContext.HttpContext.Session[sessionKey];
            }

            // Создать объект UserModel если он не обнаружен в сеансе
            if (userModel == null)
            {
                userModel = new UserModel();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = userModel;
                }
            }

            return userModel;
        }
    }
}