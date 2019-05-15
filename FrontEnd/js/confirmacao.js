$(document).ready(function(){
    $('.modal').modal();
});

document.addEventListener("DOMContentLoaded", () => {
    
    var dadosArquivados = JSON.parse(localStorage.getItem('dadosCliente'));

    document.getElementById("nome").value = dadosArquivados.dadosPessoais.nome;
    document.getElementById("nascimento").value = dadosArquivados.dadosPessoais.dataNascimento;
    document.getElementById("cpf").value = dadosArquivados.dadosPessoais.cpf;
    document.getElementById("rg").value = dadosArquivados.dadosPessoais.rg;
    document.getElementById("telefone").value = dadosArquivados.dadosPessoais.telefone;
    document.getElementById("email").value = dadosArquivados.dadosPessoais.email;
    
    document.getElementById("logradouro").value = dadosArquivados.endereco.logradouro;
    document.getElementById("numero").value = dadosArquivados.endereco.numero;
    document.getElementById("complemento").value = dadosArquivados.endereco.complemento;
    document.getElementById("bairro").value = dadosArquivados.endereco.bairro;
    document.getElementById("cidade").value = dadosArquivados.endereco.cidade;
    document.getElementById("estado").value = dadosArquivados.endereco.estado;
    
    document.getElementById("numeroCartao").value = dadosArquivados.dadosPagamento.numeroCartao;
    document.getElementById("cvv").value = dadosArquivados.dadosPagamento.cvv;
    document.getElementById("nomeCartao").value = dadosArquivados.dadosPagamento.NomeImpressoNoCartao; 
    document.getElementById("validade").value = dadosArquivados.dadosPagamento.validade;

    document.getElementById("voltar").addEventListener("click", () => {
        history.go(-1);
    });

    document.getElementById("comprar").addEventListener("click", () => {
        dadosArquivados.dadosPessoais.ip = ipUsuario;
        
        var compra = {
            "Cliente": dadosArquivados.dadosPessoais,
            "DadosPagamento": dadosArquivados.dadosPagamento,
            "Endereco": dadosArquivados.endereco
        }

        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {                    
                retorno = (JSON.parse(this.responseText));
                if(retorno == "true"){
                    $('#modal1').modal('open'); 
                }
            }
        };
        xhttp.open("POST", "http://localhost:56339/api/Compra", true);
        xhttp.setRequestHeader('Content-Type', 'application/json; charset=utf-8');
        xhttp.send(JSON.stringify( compra ));
    });

    document.getElementById("fechar").addEventListener("click", () => {
        window.location.href = "home.html";
    });
});