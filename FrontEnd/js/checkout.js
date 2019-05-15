document.addEventListener("DOMContentLoaded", () => {
    document.getElementById("btnProximo").addEventListener("click", () => {
        
        localStorage.clear();

        var dadosCliente = {
            dadosPessoais: {
                nome: document.getElementById("nome").value,
                dataNascimento: document.getElementById("nascimento").value,
                cpf: document.getElementById("cpf").value,
                rg: document.getElementById("rg").value,
                telefone: document.getElementById("telefone").value,
                email: document.getElementById("email").value
            },
            endereco: {
                logradouro: document.getElementById("logradouro").value,
                numero: document.getElementById("numero").value,
                complemento: document.getElementById("complemento").value,
                bairro: document.getElementById("bairro").value,
                cidade: document.getElementById("cidade").value,
                estado: document.getElementById("estado").value
            },
            dadosPagamento: {
                numeroCartao: document.getElementById("numeroCartao").value,
                cvv: document.getElementById("cvv").value,
                NomeImpressoNoCartao: document.getElementById("nomeCartao").value,
                validade: document.getElementById("validade").value
            } 
        }
        
        if(valida(dadosCliente)){
            var dados = JSON.stringify(dadosCliente);
            localStorage.setItem('dadosCliente', dados );

            window.location.href = "confirmacao.html";
        }
    });

    function valida(dadosCliente){
        var retorno = true;

        if(dadosCliente.dadosPessoais.nome == ""){
            retorno = false;
            $('.toast').remove();
            M.toast({html: 'Por favor informe seu nome.', classes: 'rounded'});
        }
        else if(dadosCliente.dadosPessoais.dataNascimento == ""){
            retorno = false;
            $('.toast').remove();
            M.toast({html: 'Por favor informe a sua data de nascimento.', classes: 'rounded'});
        }
        else if(dadosCliente.dadosPessoais.cpf == ""){
            retorno = false;
            $('.toast').remove();
            M.toast({html: 'Por favor informe seu CPF.', classes: 'rounded'});
        }
        else if(dadosCliente.dadosPessoais.rg == ""){
            retorno = false;
            $('.toast').remove();
            M.toast({html: 'Por favor informe o seu RG.', classes: 'rounded'});
        }
        else if(dadosCliente.dadosPessoais.telefone == ""){
            retorno = false;
            $('.toast').remove();
            M.toast({html: 'Por favor informe seu telefone.', classes: 'rounded'});
        }
        else if(dadosCliente.dadosPessoais.email == ""){
            retorno = false;
            $('.toast').remove();
            M.toast({html: 'Por favor informe seu E-mail.', classes: 'rounded'});
        }
        else if(dadosCliente.endereco.logradouro == ""){
            retorno = false;
            $('.toast').remove();
            M.toast({html: 'Por favor informe o logradouro.', classes: 'rounded'});
        }
        else if(dadosCliente.endereco.numero == ""){
            retorno = false;
            $('.toast').remove();
            M.toast({html: 'Por favor informe o número.', classes: 'rounded'});
        }
        else if(dadosCliente.endereco.bairro == ""){
            retorno = false;
            $('.toast').remove();
            M.toast({html: 'Por favor informe o bairro.', classes: 'rounded'});
        }
        else if(dadosCliente.endereco.cidade == ""){
            retorno = false;
            $('.toast').remove();
            M.toast({html: 'Por favor informe a cidade.', classes: 'rounded'});
        }
        else if(dadosCliente.endereco.estado == ""){
            retorno = false;
            $('.toast').remove();
            M.toast({html: 'Por favor informe o estado.', classes: 'rounded'});
        }
        else if(dadosCliente.dadosPagamento.numeroCartao == ""){
            retorno = false;
            $('.toast').remove();
            M.toast({html: 'Por favor informe o número do cartão de crédito.', classes: 'rounded'});
        }
        else if(dadosCliente.dadosPagamento.cvv == ""){
            retorno = false;
            $('.toast').remove();
            M.toast({html: 'Por favor informe o CVV do cartão de crédito.', classes: 'rounded'});
        }
        else if(dadosCliente.dadosPagamento.NomeImpressoNoCartao == ""){
            retorno = false;
            $('.toast').remove();
            M.toast({html: 'Por favor informe o nome impresso no cartão de crédito.', classes: 'rounded'});
        }
        else if(dadosCliente.dadosPagamento.validade == ""){
            retorno = false;
            $('.toast').remove();
            M.toast({html: 'Por favor a data de validade do cartão de crédito.', classes: 'rounded'});
        }

        return retorno;
    }
});   