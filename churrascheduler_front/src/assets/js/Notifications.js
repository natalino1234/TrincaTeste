import { ToastsStore } from "react-toasts";
import React from 'react';
import '../css/notifications.css';

const timeToRead = 1000;

export const alert = {
    success: (mensagem) => {
        if (mensagem === undefined) return;
        ToastsStore.info(<div><i className="fas fa-check-circle" /><span>{mensagem}</span></div>, (mensagem.split(" ").length + 1) * timeToRead);
    },
    error: (mensagem) => {
        if (mensagem === undefined) return;
        ToastsStore.info(<div><i className="fas fa-exclamation-circle" /><span>{mensagem}</span></div>, (mensagem.split(" ").length + 1) * timeToRead);
    }, 
    info: (mensagem) => {
        if (mensagem === undefined) return;
        ToastsStore.info(<div><i className="fas fa-info-circle" /><span>{mensagem}</span></div>, (mensagem.split(" ").length + 1) * timeToRead);
    } 
}