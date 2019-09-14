import Login from "../../pages/Login/Login";
import Cadastro from "../../pages/Cadastro/Cadastro";
import DetalharChurras from "../../pages/DetalharChurras/DetalharChurras";
import ListaChurras from "../../pages/ListaChurras/ListaChurras";
import NovoChurrasco from "../../pages/NovoChurrasco/NovoChurrasco";

export const routes = [
    {
        path: "/",
        component: Login,
        exact: true,
        needLogin: false
    },
    {
        path: "/Cadastro",
        component: Cadastro,
        exact: true,
        needLogin: false
    },
    {
        path: "/Detalhar",
        component: DetalharChurras,
        exact: true,
        needLogin: true
    },
    {
        path: "/",
        component: ListaChurras,
        exact: true,
        needLogin: true
    },
    {
        path: "/Novo",
        component: NovoChurrasco,
        exact: true,
        needLogin: true
    },
];