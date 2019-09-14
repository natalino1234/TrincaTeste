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
    let url = 'https://localhost:5001/api/Usuario/create?nome='+nome+'&login=' + email + '&senha=' + senha;
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