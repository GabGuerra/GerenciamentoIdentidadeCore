function InserirModulo() {
    let modulo = {
        CodModulo: 0,
        NomeModulo: $("#inputNomeModulo").val()
    };
    $.ajax({
        url: "../Modulo/InserirModulo",
        data: modulo,
        dataType: "json"
    });
};