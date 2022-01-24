import { Component } from '@angular/core';
import { createStore } from 'devextreme-aspnet-data-nojquery';
import CustomStore from 'devextreme/data/custom_store';
import { VentaDetalleComponent } from '../ventadetalle/ventadetalle.component';

@Component({
  templateUrl: 'ventas.component.html'
})

export class VentasComponent {
  store: CustomStore;
  constructor() {
      let serviceUrl = "http://localhost:48555/api";
      this.store = createStore({
          key: "id",
          loadUrl: serviceUrl + "/Venta"
      });
  }

}
