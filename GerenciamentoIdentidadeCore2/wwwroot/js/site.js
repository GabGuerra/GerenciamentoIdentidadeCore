let globalUrl = window.location.origin;
function RedirecionaParaPagina(controller, pagina) {
    window.location.href = globalUrl.concat("/", controller, "/", pagina);
};

