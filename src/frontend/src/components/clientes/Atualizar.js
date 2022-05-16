import React, {useEffect, useState } from 'react'
import Api from "../../services/clientes-api"

export default function Atualizar({ cliente }) {

    const [formulario, setFormulario] = useState({
        Nome: cliente.Nome,
        Porte: cliente.Porte
    });

    const onChange = event => {
        const { name, value } = event.target;
        setFormulario({...formulario, [name]: value});
    }

    const onAtualizar = async () => {
        const request = { ...formulario, Id: cliente.Id };
        const response = await Api.put(`/${cliente.Id}`, request);
        if(response.status == 202){
            document.getElementById("fecharAtualizarModal").click();
        }
    }

    const { Nome, Porte } = cliente;

  return (
    <div className="modal fade" id="atualizarModal" tabIndex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div className="modal-dialog" role="document">
            <div className="modal-content">
                <div className="modal-header">
                    <h5 className="modal-title">Atualizar Cliente</h5>
                    <button type="button" className="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <form>
                    <div className="modal-body">
                        <div className="row">
                            <div className="input-field col s4">
                                <label className="input-field" htmlFor="Nome">Nome</label>
                                <input
                                    className="validate"
                                    id="Nome"
                                    type="text"
                                    name="Nome"
                                    value={formulario.Nome || Nome}
                                    onChange={onChange}
                                />
                            </div>

                            <div className="input-field col s4">
                                <label className="input-field" htmlFor="Porte">Porte</label>
                                <input
                                    className="validate"
                                    id="Porte"
                                    type="text"
                                    name="Porte"
                                    value={formulario.Porte || Porte}
                                    onChange={onChange}
                                />

                            </div>


                        </div>

                        <button type="button" onClick={onAtualizar} className="btn btn-primary btn-sm">Cadastrar</button>
                        <button type="button" id="fecharAtualizarModal" className="btn btn-secondary btn-sm" data-dismiss="modal">Cancelar</button>
                    </div>
               </form>
            </div>
        </div>
    </div>
  )
}
