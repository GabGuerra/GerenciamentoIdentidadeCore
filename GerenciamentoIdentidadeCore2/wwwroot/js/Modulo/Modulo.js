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
                RedirecionaParaPagina("Modulo", "Index")
            }
        },
        error: function (result) {
            alert(result.mensagem);
        }       
    });
};

