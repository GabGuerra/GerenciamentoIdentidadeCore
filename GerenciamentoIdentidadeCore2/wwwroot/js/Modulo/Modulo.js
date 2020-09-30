$(document).ready(function () {
    $("#gridPesquisarModulo").hide();
   
});
//#region FUNCIONAMENTO DO INPUT PESQUISA
$("#InputPesquisaModulo").on("keyup", function () {
    var value = $(this).val().toLowerCase();
    $("tr").filter(function () {
        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
    });
});
//#endregion
//#region INSERE MODULO
function InserirModulo() {
    let modulo = {
        CodModulo: 0,
        NomeModulo: $("#inputNomeModulo").val()
    };
    $.ajax({
        url: "../Modulo/InserirModulo",
        data: modulo,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (!result.sucesso)
                alert(result.mensagem);
            else {
                alert("Módulo registrado com sucesso!");
                RedirecionaParaPagina("Modulo", "Index");
            }
        },
        error: function (result) {
            alert(result.mensagem);
        }
    });
};
//#endregion
//#region REMOVE MODULO
function RemoverModulo(codModulo) {
    let modulo = {
        CodModulo: codModulo,
        NomeModulo: ""
    };
    $.ajax({
        url: "../Modulo/RemoverModulo",
        data: modulo,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (!result.sucesso)
                alert(result.mensagem);
            else {
                alert("Módulo Excluido com sucesso!");
                RedirecionaParaPagina("Modulo", "Index");
            }
        },
        error: function (result) {
            alert(result.mensagem);
        }
    });
}
//#endregion
//#region EDITA MODULO
$('#modalEdicao').on('show.bs.modal', function (event) {
    let auxClick = $(event.relatedTarget)   
    $("#NomeModulo").val($("#NomeModuloSelecionado").val())
})
function SalvarEditModulo() {  
    let modulo = {
        CodModulo: $("#CodModuloSelecionado").val(),
        NomeModulo: $("#NomeModulo").val()
    };
    $.ajax({
        url: "../Modulo/EditarModulo",
        data: modulo,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (!result.sucesso)
                alert(result.mensagem);
            else {
                alert("Módulo Atualizado com sucesso!");                
                RedirecionaParaPagina("Modulo", "Index");
            }
        },
        error: function (result) {
            alert(result.mensagem);
        }
    });
}
//#endregion





