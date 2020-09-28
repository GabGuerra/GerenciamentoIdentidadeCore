$("#CadastroPerfilForm").submit(function (e) {    
    let Perfil = {
        CodPerfil: 0,
        NomePerfil: $('input[name="InputDscPerfil"]').val()
    };
    e.preventDefault();    
    $.ajax({
        url: "/Perfil/InserirPerfil",
        data: Perfil,
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