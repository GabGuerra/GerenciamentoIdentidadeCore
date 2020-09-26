$("#CadastroPerfilForm").submit(function (e) {    
    let Perfil = {
        Perfil: 0,
        DscPerfil: $('input[name="InputDscPerfil"]').val()
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