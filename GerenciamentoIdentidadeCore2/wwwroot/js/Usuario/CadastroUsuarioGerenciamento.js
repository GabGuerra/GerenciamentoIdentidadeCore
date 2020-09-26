$("#CadastroUsuarioGerenciamentoForm").submit(function (e) {
    e.preventDefault();

    var inputs = $("#LoginForm input");    
    let cpf = $('#LoginForm input[name="cpf"]').val();
    let usuario = { Email: email, Senha: senha };

    $.ajax({

        url: "/UsuarioGerenciamento/InserirUsuario",
        data: usuario,
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