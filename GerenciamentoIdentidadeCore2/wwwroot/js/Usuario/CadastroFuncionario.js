$(document).ready(function () {
    $("#gridPesquisarFuncionario").hide();
    SetarMascaraCpf("#inputCpfCadFuncionario");
});
//#region FUNCIONAMENTO DO INPUT PESQUISA
$("#InputPesquisaFuncionario").on("keyup", function () {
    var value = $(this).val().toLowerCase();
    $("tr").filter(function () {
        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
    });
});
//#endregion
//#region INSERE FUNCIONARIO
function InsereFuncionario() {
    let cpf = $('#inputCpfCadFuncionario').val();
    let nome = $('#inputNomeFuncionario').val();
    let codPerfil = $('#selCargo').val();
    $.ajax({
        url: "/Funcionario/InserirFuncionario",
        data: { cpf: cpf, nome: nome, codPerfil: codPerfil },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.sucesso) {
                alert("Funcionário inserido com sucesso!")
                RedirecionaParaPagina("Funcionario", "Index");
            }
            else
                alert("Erro ao inserir novo funcionário");
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
        data: { cpf: Cpf },
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
//#region EDITA FUNCIONARIO
$('#modalEdicao').on('show.bs.modal', function (event) {
    let auxClick = $(event.relatedTarget)
    let index = auxClick.data('whatever')
    let objAux = $("tr").eq(index).data()
    $("#cpfFuncionarioSelecionado").val(objAux.cpf)
    $("#selPerfil").val(objAux.codperfil);
    $("#NomeFuncionario").val(objAux.nome);

    //$("#idModulo").val(dados)
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

