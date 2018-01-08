using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace FormCollectionConvertToModel.MyConverter
{

    public class FormCollectionToModel<T> where T : class
    {

        public FormCollection formdata { get; set; }

        public FormCollectionToModel() { }
        public FormCollectionToModel(FormCollection fc)
        {
            formdata = fc;
        }

        public T GetModel {
            get {
                try
                {
                    T result = (T)Activator.CreateInstance(typeof(T));

                    //var json = Newtonsoft.Json.JsonConvert.SerializeObject(formdata);

                    //T result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);


                    foreach (var k in typeof(T).GetProperties())
                    {
                        var sd = formdata[k.Name.ToString()];

                        PropertyInfo propertyInfo = result.GetType().GetProperty(k.Name);
                        if (sd != null)
                        {
                            var _Sd = Convert.ChangeType(sd, propertyInfo.PropertyType);

                            propertyInfo.SetValue(result, _Sd, null);
                        }
                        //result.GetType().GetProperty(k.Name).SetValue(k.Name,sd);
                        //result.GetType().GetProperty(k.Name).SetValue(k, k.Name, null);

                    }

                    // var sdsd =  Converters.ToType<T>(formdata, typeof(T));

                    return result;
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }
 

    }

}