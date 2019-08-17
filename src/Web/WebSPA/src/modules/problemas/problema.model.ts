export class Problema {
    id: number;
	codigo: string;
	descricao: string;
    acoes_Corretivas: string;
    dataInicio: Date;
    local: string;
    turno: string;
    quemReportou: string;
    dataFim: Date;
    estado: string;
    naoConformidade: string;
    idProdutoProcesso: string;
    nomeProdutoProcesso: string;
    acoes_Executadas: string;
    comentarios: [{
        data: Date;
        userLogin: string;
        texto: string;
    }];
}
