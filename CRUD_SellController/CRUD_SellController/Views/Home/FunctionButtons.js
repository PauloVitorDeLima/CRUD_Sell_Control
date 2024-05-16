function carregarInformacoesProduto() {
    $.ajax({
        url: '@Url.Action("CarregarDadosProduto", "Produto")',
        type: 'GET',
        success: function () {
            alert('Lista atualizada');
        },
        error: function () {
            alert('Ocorreu um erro ao carregar as informações do endpoint.');
        }
    });
}
function carregarInformacoesCliente() {
    $.ajax({
        url: '@Url.Action("CarregarDadosCliente", "Cliente")',
        type: 'GET',
        success: function () {
            alert('Lista atualizada');
        },
        error: function () {
            alert('Ocorreu um erro ao carregar as informações do endpoint.');
        }
    });
}

function carregarInformacoesVenda() {
    $.ajax({
        url: '@Url.Action("CarregarDadosVenda", "Venda")',
        type: 'GET',
        success: function () {
            alert('Lista atualizada');
        },
        error: function () {
            alert('Ocorreu um erro ao carregar as informações do endpoint.');
        }
    });
}