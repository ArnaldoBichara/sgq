export class CadAtividade {
    codigo: string;
    titulo: string;
    descricao: string;
    usergroup: string;
    normapadrao: {
        tipo: string;
        codigo: string;
        titulo: string;
    };
    processoproduto: [{
        tipo: string;
        codigo: string;
        nome: string;
    }];
}
