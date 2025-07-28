const API_BASE_URL = 'http://localhost:5000/api';

function formatarMoeda(valor) {
    return new Intl.NumberFormat('pt-BR', {
        style: 'currency',
        currency: 'BRL'
    }).format(valor);
}

function formatarPercentual(valor) {
    return valor.toFixed(2) + '%';
}

async function carregarDados() {
    const loadingEl = document.getElementById('loading');
    const errorEl = document.getElementById('error');
    const contentEl = document.getElementById('content');

    loadingEl.style.display = 'block';
    errorEl.style.display = 'none';
    contentEl.style.display = 'none';

    try {
        const response = await fetch(`${API_BASE_URL}/seguro/relatorio/medias`);

        if (!response.ok) {
            throw new Error(`Erro na API: ${response.status}`);
        }

        const dados = await response.json();

        document.getElementById('totalSeguros').textContent = dados.totalSeguros;
        document.getElementById('mediaValorVeiculo').textContent = formatarMoeda(dados.mediaValorVeiculo || 0);
        document.getElementById('mediaTaxaRisco').textContent = formatarPercentual(dados.mediaTaxaRisco || 0);
        document.getElementById('mediaPremioRisco').textContent = formatarMoeda(dados.mediaPremioRisco || 0);
        document.getElementById('mediaPremioPuro').textContent = formatarMoeda(dados.mediaPremioPuro || 0);
        document.getElementById('mediaPremioComercial').textContent = formatarMoeda(dados.mediaPremioComercial || 0);
        document.getElementById('mediaValorSeguro').textContent = formatarMoeda(dados.mediaValorSeguro || 0);

        loadingEl.style.display = 'none';
        contentEl.style.display = 'block';

    } catch (error) {
        console.error('Erro ao carregar dados:', error);

        errorEl.textContent = `Erro ao carregar dados: ${error.message}. Verifique se a API está rodando em ${API_BASE_URL}`;
        errorEl.style.display = 'block';
        loadingEl.style.display = 'none';
    }
}

document.addEventListener('DOMContentLoaded', carregarDados);