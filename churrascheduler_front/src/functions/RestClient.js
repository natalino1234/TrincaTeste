export const Authenticate = (email, senha, callback) => {
    let url = 'https://localhost:5001/api/Usuario/Authenticate?login='+email+'&senha='+senha;
    fetch(url, {
        method: "POST",
        mode: 'cors',
        headers: {
            'Content-type': 'application/json',
            "Access-Control-Allow-Origin": "*",
            "Access-Control-Allow-Credentials": "true",
            "Access-Control-Allow-Methods": "GET, POST, OPTIONS"
        }
    })
        .then(response => {
            return response.json();
        })
        .then(response => {
            callback(response);
        });
};

export const SignUp = (nome, email, senha, callback) => {
    let url = 'https://localhost:5001/api/Usuario/create?login=' + email + '&senha=' + senha + '&nome=' + nome;
    console.log(url);
    fetch(url, {
        method: "POST",
        mode: 'cors',
        headers: {
            'Content-type': 'application/json',
            "Access-Control-Allow-Origin": "*",
            "Access-Control-Allow-Credentials": "true",
            "Access-Control-Allow-Methods": "GET, POST, OPTIONS"
        }
    })
        .then(response => {
            return response.json();
        })
        .then(response => {
            callback(response);
        });
};

export const ListChurras = (authtoken, callback) => {
    let url = 'https://localhost:5001/api/Churras/List?authtoken=' + authtoken;
    fetch(url, {
        method: "POST",
        mode: 'cors',
        headers: {
            'Content-type': 'application/json',
            "Access-Control-Allow-Origin": "*",
            "Access-Control-Allow-Credentials": "true",
            "Access-Control-Allow-Methods": "GET, POST, OPTIONS"
        }
    })
        .then(response => {
            return response.json();
        })
        .then(response => {
            callback(response);
        })
        .catch(err => {
            console.log("DEU RUIM");
        });
};

export const SalvarChurrasco = (authtoken, descricao, data, bebidaIncluida, observacoes, valorIndividual, callback) => {
    let url = "https://localhost:5001/api/Churras/Create?"+
        "authToken=" + authtoken +
        "&descricao=" + descricao +
        "&data=" + data +
        "&bebidaIncluida=" + bebidaIncluida +
        "&observacoes=" + observacoes +
        "&valorParticipante=" + valorIndividual;
    fetch(url, {
        method: "POST",
        mode: 'cors',
        headers: {
            'Content-type': 'application/json',
            "Access-Control-Allow-Origin": "*",
            "Access-Control-Allow-Credentials": "true",
            "Access-Control-Allow-Methods": "GET, POST, OPTIONS"
        }
    })
        .then(response => {
            return response.json();
        })
        .then(response => {
            callback(response);
        })
        .catch(err => {
            console.log("DEU RUIM");
        });
};

export const DetailChurras = (authtoken, id_churras, callback) => {
    let url = 'https://localhost:5001/api/Churras/Detail?authtoken=' + authtoken+'&id='+id_churras;
    fetch(url, {
        method: "POST",
        mode: 'cors',
        headers: {
            'Content-type': 'application/json',
            "Access-Control-Allow-Origin": "*",
            "Access-Control-Allow-Credentials": "true",
            "Access-Control-Allow-Methods": "GET, POST, OPTIONS"
        }
    })
        .then(response => {
            return response.json();
        })
        .then(response => {
            callback(response);
        })
        .catch(err => {
            console.log("DEU RUIM");
        });
};

export const AddParticipante = (authtoken, id_churras, nome_participante, pago, callback) => {
    let url = 'https://localhost:5001/api/Churras/AddParticipante?authtoken=' + authtoken +
        '&id_churras=' + id_churras +
        "&nome=" + nome_participante +
        "&pago="+pago;
    fetch(url, {
        method: "POST",
        mode: 'cors',
        headers: {
            'Content-type': 'application/json',
            "Access-Control-Allow-Origin": "*",
            "Access-Control-Allow-Credentials": "true",
            "Access-Control-Allow-Methods": "GET, POST, OPTIONS"
        }
    })
        .then(response => {
            return response.json();
        })
        .then(response => {
            callback(response);
        })
        .catch(err => {
            console.log("DEU RUIM");
        });
};

export const RemParticipante = (authtoken, id_churras, id_participante, callback) => {
    let url = 'https://localhost:5001/api/Churras/RemParticipante?authtoken=' + authtoken +
        '&id_churras=' + id_churras +
        "&id_participante=" + id_participante;
    fetch(url, {
        method: "POST",
        mode: 'cors',
        headers: {
            'Content-type': 'application/json',
            "Access-Control-Allow-Origin": "*",
            "Access-Control-Allow-Credentials": "true",
            "Access-Control-Allow-Methods": "GET, POST, OPTIONS"
        }
    })
        .then(response => {
            return response.json();
        })
        .then(response => {
            callback(response);
        })
        .catch(err => {
            console.log("DEU RUIM");
        });
};

export const EditParticipante = (authtoken, id_participante, id_churras, nome_participante, pago, callback) => {
    let url = 'https://localhost:5001/api/Churras/EditParticipante?authtoken=' + authtoken +
        '&id_churras=' + id_churras +
        '&id_participante=' + id_participante +
        "&nome=" + nome_participante +
        "&pago=" + pago;
    fetch(url, {
        method: "POST",
        mode: 'cors',
        headers: {
            'Content-type': 'application/json',
            "Access-Control-Allow-Origin": "*",
            "Access-Control-Allow-Credentials": "true",
            "Access-Control-Allow-Methods": "GET, POST, OPTIONS"
        }
    })
        .then(response => {
            return response.json();
        })
        .then(response => {
            callback(response);
        })
        .catch(err => {
            console.log("DEU RUIM");
        });
};
