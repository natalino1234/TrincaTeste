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