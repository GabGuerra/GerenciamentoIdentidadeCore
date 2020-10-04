$(document).ready(function () {
    $("#gridPesquisarPerfil").hide();
});
//#region FUNCIONAMENTO DO INPUT PESQUISA
$("#InputPesquisaPerfil").on("keyup", function () {
    var value = $(this).val().toLowerCase();
    $("tr").filter(function () {
        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
    });
});
//#endregion


$("#CadastroPerfilForm").submit(function (e) {
    let perfil = {
        CodPerfil: 0,
        NomePerfil: $('input[name="InputDscPerfil"]').val()
    };

    let listaModulosPermitidos = "";

    $("[id^=chkPermissaoModulo_]").each(function () {
        let $checkbox = $(this);

        if ($checkbox.prop("checked"))
            listaModulosPermitidos = listaModulosPermitidos + $checkbox.val() + ",";
    });

    $.ajax({
        url: "/Perfil/InserirPerfilPermissao",
        data: { NomePerfil: perfil.NomePerfil, listaModulosPermitidos: listaModulosPermitidos },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (result) {
            if (result.sucesso) {
                alert("Sucesso");
            }
            else {
                alert("Erro ao cadastrar Perfil.");
            }
        },
        error: function (result) {
            console.log(result);
        }
    });
    RedirecionaParaPagina("Perfil", "CadastroPerfil");
});

//#region EDITA FUNCIONARIO
$('#modalEdicao').on('show.bs.modal', function (event) {
    let auxClick = $(event.relatedTarget)
    let index = auxClick.data('whatever')
    let objAux = $("tr").eq(index).data()
    $("#codPerfilSelecionado").val(objAux.codPerfil)
    $("#NomePerfil").val(objAux.nome);
    $("[id^=chkPermissaoModuloGrid_]").each(function () {
        let $checkbox = $(this);
        $checkbox.prop("checked", false)
    });
    //$("[id^=chkPermissaoModuloGrid_]").prop('checked', false);
    $.ajax({
        url: "/Perfil/CarregaListaPermissoesPerfil",
        data: { codPerfil: objAux.codPerfil },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (data) {
            if (data) {
                console.log("permissoes: " + data)
                CheckarPermissoesEdicaoPerfil(data);
            }
            else
                console.log("sem permissoes")
        },
        error: function (result) {
            console.log("erro");
        }
    });

});

var CheckarPermissoesEdicaoPerfil = function (data) {

    let auxCheckModulosPermitidos = data && data.length > 0 ? data.split(",") : "";

    let listaModulosPermitidos = "";
    
    $("[id^=chkPermissaoModuloGrid_]").each(function () {
        let $checkbox = $(this);
        auxCheckModulosPermitidos.forEach(function (element) {
            if (element && !$checkbox.prop("checked")) {
                if ($checkbox.val() == element) {
                    $checkbox.prop("checked", true)
                }
                else
                    $checkbox.prop("checked", false)
            }
        })
    });
 }
var SalvarEditPerfil = function () {
    let CodPerfil = $("#codPerfilSelecionado").val();
    let Nome = $("#NomePerfil").val();
    let listaModulosPermitidos = "";
    $("[id^=chkPermissaoModuloGrid_]").each(function () {
        let $checkbox = $(this);

        if ($checkbox.prop("checked"))
            listaModulosPermitidos = listaModulosPermitidos + $checkbox.val() + ",";
    });
    //let CodPerfil = Number($("#selPerfil").val());
    $.ajax({
        url: "/Perfil/AtualizarPerfil",
        data: { codPerfil: CodPerfil, nomePerfil: Nome, listaPermissoesPerfil: listaModulosPermitidos},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (result) {
            if (result.sucesso) {
                alert("Perfil Atualizado com sucesso!");
            }
            else
                alert("Erro ao atualizar o perfil");
        },
        error: function (result) {
            console.log(result);
        }
    });
    RedirecionaParaPagina("Perfil", "CadastroPerfil");
};
//#endregion

var RemoverPerfil = function (codPerfil) {
    $.ajax({
        url: "/Perfil/RemoverPerfil",
        data: { codPerfil: codPerfil },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (result) {
            if (result.sucesso) {
                alert("Perfil Removido com sucesso!");

            }
            else
                alert(result.Mensagem);
        },
        error: function (result) {
            console.log(result);
        }
    });
    RedirecionaParaPagina("Perfil", "CadastroPerfil");

}