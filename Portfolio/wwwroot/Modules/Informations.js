
var ClsInformations = {

    GetAll: function () {
                            // https://localhost:7126/api/Informations
                            // https://kemowaria900-001-site1.etempurl.com/api/Informations

        Helper.AjaxCallGet("https://localhost:7126/api/Informations", {}, "json",
            function (Response) {
                /*console.log(Response);*/

                // For Text.
                $("#firstName").text(Response.firstName);
                $("#secondName").text(Response.secondName);
                $("#phone").text(Response.phone);
                $("#email").text(Response.email);


                // For Link.
                $("#twitter").attr("href", Response.twitter);
                $("#linkedin").attr("href", Response.linkedin);
                $("#github").attr("href", Response.github);


 
                // For Images.
                      //$("#logo").attr("src","/Uploads/Logo/" + Response.logo);
                
                

            }, function () { }
        )
                            
                            // https://localhost:7126/api/Informations
                            //https://kemowaria900-001-site1.etempurl.com/api/Informations

        Helper.AjaxCallGet("https://localhost:7126/api/Informations", {}, "json",
            function (Response) {
                /*console.log(Response);*/
                

                // For Link.
                $("#Twitter").attr("href", Response.twitter);
                $("#Linkedin").attr("href", Response.linkedin);
                $("#Github").attr("href", Response.github);


                // For Images.
                //$("#logo").attr("src","/Uploads/Logo/" + Response.logo);



            }, function () { }
        )

    }




}

ClsInformations.GetAll();