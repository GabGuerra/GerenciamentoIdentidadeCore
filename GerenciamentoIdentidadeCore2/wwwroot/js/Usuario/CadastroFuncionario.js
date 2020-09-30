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

function SalvarEditFuncionario() {
    let Cpf = $("#cpfFuncionarioSelecionado").val();
    let Nome = $("#NomeFuncionario").val();
    let CodPerfil = Number($("#selPerfil").val());
    $.ajax({
        url: "/Funcionario/AtualizarFuncionario",
        data: { cpf: Cpf, nome: Nome, codPerfil: CodPerfil },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.sucesso) {
                alert("Funcionário Atualizado com sucesso!");    
                RedirecionaParaPagina("Funcionario", "Index");                
            }
            else
                alert("Erro ao atualizar o funcionário");
        },
        error: function (result) {
            console.log(result);
        }
    });
};
//#endregion
//#region REMOVE FUNCIONARIO
function RemoverFuncionario(cpf) {
    let Cpf = cpf;
    $.ajax({
        url: "/Funcionario/RemoverFuncionario",
        data: { cpf: Cpf},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.sucesso) {
                alert("Funcionário Removido com sucesso!");
                RedirecionaParaPagina("Funcionario", "Index");
            }
            else
                alert("Erro ao remover o funcionário");
        },
        error: function (result) {
            console.log(result);
        }
    });
}
//#endregion
