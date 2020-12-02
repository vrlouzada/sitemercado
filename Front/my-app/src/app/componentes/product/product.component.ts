import { HttpResponse } from '@angular/common/http';

import { ProductService } from './../../services/product.service';
import { Product } from './../../model/product.model';
import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { UploadfileService } from 'src/app/services/uploadfile.service';
import { ProductAction } from 'src/app/constants/productaction.constant';
import { ImageDefault } from 'src/app/constants/imagemdefault.constant';


@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  public product: Product;
  products: Product[];
  selectedFile: File;
  actions: any

  constructor(
    private prodService: ProductService, 
    private modalService: NgbModal, 
    private uploadFile: UploadfileService 
    ) { }

  ngOnInit(): void {
    this.getAll();

    this.product = {
      id : 0,
      price: "",
      name: "",
      imagem: {}
    }

    this.actions = {
      save: ProductAction.SAVE,
      update: ProductAction.UPDATE
    }
  }

  resetModel(){
    this.product = {
      id : 0,
      price: "",
      name: "",
      imagem: {}
    }
  }

  getAll() {
    this.prodService.getAll().subscribe(
      data => {
        this.products = data;
        console.log('Produtors: ', data);
    }, 
    error => {
      console.error(error);
    });
  }

  create(item){
    this.prodService.create(item).subscribe(
      data => {
        if(data){
          alert('Item Criado');
          item.id = data.id;
          item.imagem = {};
          this.products.push(item);
        }else{
          alert('Ocorreu um error');
        }
      },
      error =>{
        alert('Ocorreu um error');
      })
  }

  update(item){
    let model = {
      id: item.id,
      price: item.price,
      name: item.name
    };
    this.prodService.update(model).subscribe(
      data => {
        if(data){
          alert('Item atualizado');
        }else{
          alert('Ocorreu um error');
        }
      },
      error =>{
        alert('Ocorreu um error');
      })
  }

  remove(item){
    this.prodService.remove(item).subscribe(
      data => {
        if(data){
          alert('Item removido');
          this.products = this.products.filter(a => a.id !== item.id);
        }else{
          alert('Ocorreu um error');
        }
      },
      error =>{
        alert('Ocorreu um error');
      })
  }

  openModal(content, item){
    this.product = item;
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {    
      item.price = parseFloat(item.price);
      if(result === ProductAction.SAVE){
       this.create(item);
      } 
      else if(result === ProductAction.UPDATE){
        this.update(item);
      }
      this.resetModel();
    }, (reason) => {
     this.resetModel();
      // closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });

  }

  onFileChanged(event, id) {
    this.uploadFile.upload(event.target.files[0], id).subscribe(
      data =>{      
        if((data as any).body){
          this.convertImage(event.target.files[0]).then(
            data => this.products.find(a => a.id === id).imagem.image = data           
          );  
          alert('Imagem Atualizada');
        }
             
      },
      error =>{

      })
  }

  getImage(item){  
    this.uploadFile.getImage(item).subscribe(
      data => {
        if(data.image){
          return data.image
        }else{
          return ImageDefault.SRC;
        }
      },
      error => {
        console.error(error);
      }
    )
  }

  convertImage(file){

    return new Promise((resolve, reject) => {
      const reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onload = () => resolve(reader.result);
      reader.onerror = error => reject(error);
    });

  //reader.readAsBinaryString(f);
    // let me = this;
    // let file = event.target.files[0];
    // //let reader = new FileReader();
    // reader.readAsDataURL(file);
    // reader.onload = function () {
    //   //me.modelvalue = reader.result;
    //  return reader.result;
    //   console.log(reader.result);
    // };

    // reader.onerror = function (error) {
    //   console.log('Error: ', error);
    // };
  }

}
