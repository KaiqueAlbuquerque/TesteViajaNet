var ipUsuario = "";

function getIp(callback)
{
    function response(s)
    {
        callback(window.userip);

        s.onload = s.onerror = null;
        document.body.removeChild(s);
    }

    function trigger()
    {
        window.userip = false;

        var s = document.createElement("script");
        s.async = true;
        s.onload = function() {
            response(s);
        };
        s.onerror = function() {
            response(s);
        };

        s.src = "https://l2.io/ip.js?var=userip";
        document.body.appendChild(s);
    }

    if (/^(interactive|complete)$/i.test(document.readyState)) {
        trigger();
    } else {
        document.addEventListener('DOMContentLoaded', trigger);
    }
}

getIp(function (ip) {
    ipUsuario = ip;

    var dadosNavegacao = {
        "Ip": ip,
        "NomeDaPagina": retornaNomeDaPagina(),
        "Browser": retornaNavegador() 
    }
    
    envidaDadosNavegacao(dadosNavegacao);
});

function retornaNomeDaPagina()
{
    var url  = window.location.href; 
    var urlAbsoluta = url.split("/")[url.split("/").length -1];

    return urlAbsoluta.split(".")[0];
}

function envidaDadosNavegacao(dadosNavegacao)
{
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {                    
            
        }
    };
    xhttp.open("POST", "http://localhost:56339/api/DadosNavegacao", true);
    xhttp.setRequestHeader('Content-Type', 'application/json; charset=utf-8');
    xhttp.send(JSON.stringify( dadosNavegacao ));
}

function retornaNavegador()
{
    if((navigator.userAgent.indexOf("Opera") || navigator.userAgent.indexOf('OPR')) != -1 ) 
        return 'Opera';
    else if(navigator.userAgent.indexOf("Chrome") != -1 )
        return 'Chrome';
    else if(navigator.userAgent.indexOf("Safari") != -1)
        return 'Safari';
    else if(navigator.userAgent.indexOf("Firefox") != -1 ) 
        return 'Firefox';
    else if((navigator.userAgent.indexOf("MSIE") != -1 ) || (!!document.documentMode == true )) 
        return 'IE'; 
    else 
        return 'Não identificado';
}