$("#CadastroPerfilForm").submit(function (e) {    
    let perfil = {
        CodPerfil: 0,
        NomePerfil: $('input[name="InputDscPerfil"]').val()
    };

    let listaModulosPermitidos = [];

    $("[id^=chkPermissaoModulo_]").each(function() {
        let $checkbox = $(this);

        if ($checkbox.prop("checked"))
            listaModulosPermitidos.push(Number($checkbox.val()));
    });

    e.preventDefault();    
    $.ajax({        
        url: "/Perfil/InserirPerfilPermissao",
        data: JSON.stringify({ perfil: perfil, listaModulosPermitidos: listaModulosPermitidos }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.sucesso) {
                alert("Sucesso");
                RedirecionaParaPagina("Perfil", "CadastroPerfil");
            }
            else {
                alert("Erro ao cadastrar Perfil.");
            }
        },
        error: function (result) {
            console.log(result);
        }
    }); 
});