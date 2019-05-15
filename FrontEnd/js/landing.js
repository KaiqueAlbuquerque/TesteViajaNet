$(document).ready(function(){
    $('.modal').modal();
});

document.addEventListener("DOMContentLoaded", () => {

    document.getElementById("btnEnviar").addEventListener("click", () => {
        var email = document.getElementById("email").value;

        landing = {
            "Email": email,
            "Ip": ipUsuario
        }

        if(valida(landing)){
            var xhttp = new XMLHttpRequest();
            xhttp.onreadystatechange = function () {
                if (this.readyState == 4 && this.status == 200) {                    
                    retorno = (JSON.parse(this.responseText));
                    if(retorno == "true"){
                        $('#modal1').modal('open'); 
                    }
                }
            };
            xhttp.open("POST", "http://localhost:56339/api/Landing", true);
            xhttp.setRequestHeader('Content-Type', 'application/json; charset=utf-8');
            xhttp.send(JSON.stringify( landing ));
        }
    });

    document.getElementById("fechar").addEventListener("click", () => {
        window.location.href = "home.html";
    });

    function valida(landing)
    {
        retorno = true;

        if(landing.Email == "")
        {
            retorno = false;
            $('.toast').remove();
            M.toast({html: 'Por favor informe seu E-mail.', classes: 'rounded'});
        }

        return retorno;
    }
});