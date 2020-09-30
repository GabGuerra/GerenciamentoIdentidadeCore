$(document).ready(function () {
    $("#gridPesquisarFuncionario").hide();

    SetarMascaraCpf("#inputCpfCadFuncionario");

    $("#CadastroFuncionarioForm").submit(function (e) {
        e.preventDefault();
        
        let cpf = $('#inputCpfCadFuncionario').val();
        let nome = $('#inputNomeFuncionario').val();
        let codPerfil = $('#selCargo').val();

        $.ajax({

            url: "/Funcionario/InserirFuncionario",
            data: { cpf: cpf, nome: nome, codPerfil: codPerfil },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                if (result.sucesso)
                    RedirecionarParaPaginaInicial();
                else
                    alert("Usuario e/ou senha incorretos");
            },
            error: function (result) {
                console.log(result);
            }
        });
    });


    function RemoverFuncionario(cpf) {
        alert(cpf)
    }
});