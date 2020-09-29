$(document).ready(function () {
    $("#gridPesquisarFuncionario").hide();

    SetarMascaraCpf("#inputCpfCadFuncionario");

    $("#CadastroUsuarioGerenciamentoForm").submit(function (e) {
        e.preventDefault();


        let cpf = $('#inputNomeFuncionario').val();
        let nome = $('#inputCpfCadFuncionario').val();
        let codPerfil = Number("#selCargo").val();

        $.ajax({

            url: "/UsuarioGerenciamento/InserirFunc",
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