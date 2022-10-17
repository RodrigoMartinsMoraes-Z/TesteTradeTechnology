{

    let resultado;

    let simular = function () {
        fetch('https://localhost:7197/api/Campeonato/GerarResultados', {
            method: "GET"
        }).then(response => response.json())
            .then(json => { resultado = json; exibirResultados() });

    };

    let exibirResultados = function () {
        let tela = document.getElementById("visualizarResultados");
        let html = '';

        for (const element of resultado.jogos) {
            html += `        
            <div class="row" style = "border-bottom:1px solid black" >
            <div class="col-sm-3" >
                `+ element.placar.timeA.nome + `                
            </div >
            <div class="col-sm-2">
                `+ element.placar.pontosTimeA + `
            </div>
            <div class="col-sm-2"></div>
            <div class="col-sm-2">
                `+ element.placar.timeB.nome + `
            </div>
            <div class="col-sm-3">
                `+ element.placar.pontosTimeB + `
            </div>
            </div > `;
        }

        tela.innerHTML = html;
    };

    simular();
}