# FormCollection-Convert-MVC-Model-Result
if we need to get form collection as Model when View Pages uses without Model (exceptions) this project will be able to helpful.

I have a project a View page created before me, by ex colleagues. 
It was imposible make it apply Model, becaouse there were many inputs and foreign elements have to use together on somewhere. 
i created a own method like that converting FormCollection. 

As a conclusion this way might be evaluate for different trouble to solve. 


    Controller side codes; 
  
    public ActionResult ShowFormData(FormCollection fc) 
    { 
      model = new FormCollectionToModel(fc).GetModel; 
      return View(model); 
    }
Please also check it out that GetConvertfunction function on Convertor Class.

    PropertyInfo propertyInfo = result.GetType().GetProperty(k.Name); 
    if (sd != null) 
    { 
     var _Sd = Convert.ChangeType(sd, propertyInfo.PropertyType); 
     propertyInfo.SetValue(result, _Sd, null); 
    }
