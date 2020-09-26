$("#LoginForm").submit(function (e) {
    var inputs = $("#LoginForm input");
    let senha = $('#LoginForm input[name="inputSenhaLogin"]').val();
    let email = $('#LoginForm input[name="inputEmailLogin"]').val();
    let usuario = { Email: email, Senha: senha };

    $.ajax({

        url: "/Login/RealizarLogin",
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
    e.preventDefault();


    function RedirecionarParaPaginaInicial() {
        window.location.href = window.location.origin + "/Home/Index";
    };
});