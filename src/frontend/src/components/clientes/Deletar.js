import React, {useEffect, useState } from 'react'
import Api from "../../services/clientes-api"

export default function Deletar({ cliente, recarregar }) {

    const onDeletar = async () => {
        const response = await Api.delete(`/${cliente.Id}`);
        if(response.status == 202){
            recarregar();
            document.getElementById("fecharDeletarModal").click();
        }
    }

    const { Nome } = cliente;

  return (
    <div className="modal fade" id="deletarModal" tabIndex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div className="modal-dialog" role="document">
            <div className="modal-content">
                <div className="modal-header">
                    <h5 className="modal-title">Deletar Cliente</h5>
                    <button type="button" className="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <form>
                    <div className="modal-body">
                        <p>Deseja realmente deletar o cliente {Nome}</p>

                        <button type="button" onClick={onDeletar} className="btn btn-danger btn-sm">Deletar</button>
                        <button type="button" id="fecharDeletarModal" className="btn btn-secondary btn-sm" data-dismiss="modal">Cancelar</button>
                    </div>
               </form>
            </div>
        </div>
    </div>
  )
}
