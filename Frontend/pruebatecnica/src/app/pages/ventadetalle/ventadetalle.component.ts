import { Component } from '@angular/core';
import { createStore } from 'devextreme-aspnet-data-nojquery';
import CustomStore from 'devextreme/data/custom_store';

@Component({
  templateUrl: 'ventadetalle.component.html'
})

export class VentaDetalleComponent {
  store: CustomStore;
  constructor() {
      let serviceUrl = "http://localhost:48555/api";
      this.store = createStore({
          key: "id",
          loadUrl: serviceUrl + "/VentaDetalle?Venta=2"
      });
  }

}
