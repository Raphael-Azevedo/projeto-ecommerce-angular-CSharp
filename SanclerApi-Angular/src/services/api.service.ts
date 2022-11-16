import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { catchError, tap, map } from 'rxjs/operators';
import { Produto } from 'src/model/produto';
import { Usuario } from 'src/model/usuario';
import { Comments } from 'src/model/comments';
import { Assessment } from 'src/model/assessment';
import { produtoContainer } from 'src/model/produtoContainer';
import { CommentContainer } from 'src/model/commentContainer';
import { Inventory } from 'src/model/inventory';
import { InventoryContainer } from 'src/model/inventoryContainer';
import { AssessmentContainer } from 'src/model/assessmentContainer';


const apiUrl = 'https://localhost:5001/api/v1/products';
const commentsUrl = 'https://localhost:5001/api/v1/comments';
const assessmentUrl = 'https://localhost:5001/api/v1/assessment';
const inventoryUrl = 'https://localhost:5001/api/v1/inventory';
const apiLoginUrl = 'https://localhost:5001/api/v1/Autorization/login';
var token;
var httpOptions = {headers: new HttpHeaders({"Content-Type": "application/json"})};

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  montaHeaderToken() {
    token = localStorage.getItem("jwt");
    console.log('jwt header token ' + token);
    httpOptions = {headers: new HttpHeaders({"Authorization": "Bearer " + token,"Content-Type": "application/json"})};
  }

  Login (Usuario:Usuario): Observable<Usuario> {
    return this.http.post<Usuario>(apiLoginUrl, Usuario).pipe(
      tap((Usuario: Usuario) => console.log(`Login usuario com email =${Usuario.email}`)),
      catchError(this.handleError<Usuario>('Login'))
    );
  }

  getProdutos (): Observable<Produto[]> {
    this.montaHeaderToken();
    console.log(httpOptions.headers);
    return this.http.get<Produto[]>(apiUrl, httpOptions)
      .pipe(
        tap(Produtos => console.log('leu os Produtos')),
        catchError(this.handleError('getProdutos', []))
      );
  }
  getProdutosCard (): Observable<produtoContainer[]> {
    this.montaHeaderToken();
    console.log(httpOptions.headers);
    return this.http.get<produtoContainer[]>(apiUrl, httpOptions)
      .pipe(
        tap(Produtos => console.log('leu os Produtos')),
        catchError(this.handleError('getProdutos', []))
      );
  }

  getProduto(id: number): Observable<produtoContainer> {
    this.montaHeaderToken();
    const url = `${apiUrl}/Product/${id}`;
    return this.http.get<produtoContainer>(url, httpOptions).pipe(
      tap(_ => console.log(`leu o Produto id=${id}`)),
      catchError(this.handleError<produtoContainer>(`getProduto id=${id}`))
    );
  }

  addProduto (Produto:Produto): Observable<Produto> {
    this.montaHeaderToken();
    return this.http.post<Produto>(apiUrl, Produto, httpOptions).pipe(
      tap((Produto: Produto) => console.log(`adicionou um Produto `)),
      catchError(this.handleError<Produto>('addProduto'))
    );
  }

  updateProduto(id = Number, Produto:Produto): Observable<any> {
    const url = `${apiUrl}/${id}`;
    return this.http.put(url, Produto, httpOptions).pipe(
      tap(_ => console.log(`atualiza o produco com id=${id}`)),
      catchError(this.handleError<any>('updateProduto'))
    );
  }

  deleteProduto (id:number): Observable<Produto> {
    const url = `${apiUrl}/${id}`;
    return this.http.delete<Produto>(url, httpOptions).pipe(
      tap(_ => console.log(`remove o Produto com id=${id}`)),
      catchError(this.handleError<Produto>('deleteProduto'))
    );
  }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  }

  getComentarios (id: number): Observable<Comments[]> {
    this.montaHeaderToken();
    console.log(httpOptions.headers);
    const url = `${commentsUrl}/GetByProductId/${id}`;
    return this.http.get<Comments[]>(url, httpOptions)
      .pipe(
        tap(Comments => console.log('leu os comments')),
        catchError(this.handleError('getComments', []))
      );
  }

  getComentario(id: number): Observable<CommentContainer> {
    const url = `${commentsUrl}/${id}`;
    return this.http.get<CommentContainer>(url, httpOptions).pipe(
      tap(_ => console.log(`leu o comentario id=${id}`)),
      catchError(this.handleError<CommentContainer>(`getComment id=${id}`))
    );
  }
  getComentarioFront(id: number): Observable<CommentContainer[]> {
    const url = `${commentsUrl}/GetByProductId/${id}`;
    return this.http.get<CommentContainer[]>(url, httpOptions).pipe(
      tap(_ => console.log(`leu o comentario id=${id}`)),
      catchError(this.handleError<CommentContainer[]>(`getComment id=${id}`))
    );
  }


  addComentario (Comments:Comments): Observable<Comments> {
    this.montaHeaderToken();
    return this.http.post<Comments>(commentsUrl, Comments, httpOptions).pipe(
      tap((Comments: Comments) => console.log(`adicionou um Comentario `)),
      catchError(this.handleError<Comments>('addComentario'))
    );
  }

  updateComentario(id = Number, Comments:Comments): Observable<any> {
    const url = `${commentsUrl}/${id}`;
    return this.http.put(url, Comments, httpOptions).pipe(
      tap(_ => console.log(`atualiza o comentario com id=${id}`)),
      catchError(this.handleError<any>('updateComentario'))
    );
  }

  deleteComentario (id:number): Observable<Comments> {
    const url = `${commentsUrl}/${id}`;
    return this.http.delete<Comments>(url, httpOptions).pipe(
      tap(_ => console.log(`remove o Comentario com id=${id}`)),
      catchError(this.handleError<Comments>('deleteComentario'))
    );
  }
  getAvaliacoes (id: number): Observable<Assessment[]> {
    this.montaHeaderToken();
    console.log(httpOptions.headers);
    const url = `${assessmentUrl}/GetByProductId/${id}`;
    return this.http.get<Assessment[]>(url, httpOptions)
      .pipe(
        tap(Comments => console.log('leu as avaliações')),
        catchError(this.handleError('getAvaliacoes', []))
      );
  }
  getAvaliacao(id: number): Observable<AssessmentContainer> {
    const url = `${assessmentUrl}/${id}`;
    return this.http.get<AssessmentContainer>(url, httpOptions).pipe(
      tap(_ => console.log(`leu a avaliação id=${id}`)),
      catchError(this.handleError<AssessmentContainer>(`getAvalicao id=${id}`))
    );
  }

  addAvaliacao(Assessment:Assessment): Observable<Assessment> {
    this.montaHeaderToken();
    return this.http.post<Assessment>(assessmentUrl, Assessment, httpOptions).pipe(
      tap((Assessment: Assessment) => console.log(`adicionou uma avaliação `)),
      catchError(this.handleError<Assessment>('addAvaliação'))
    );
  }

  updateAvaliacao(id = Number, Assessment:Assessment): Observable<any> {
    const url = `${assessmentUrl}/${id}`;
    return this.http.put(url, Assessment, httpOptions).pipe(
      tap(_ => console.log(`atualiza a avaliação com id=${id}`)),
      catchError(this.handleError<any>('updateAvaliacao'))
    );
  }

  deleteAvaliacao (id:number): Observable<Assessment> {
    const url = `${assessmentUrl}/${id}`;
    return this.http.delete<Assessment>(url, httpOptions).pipe(
      tap(_ => console.log(`remove a avaliacao com id=${id}`)),
      catchError(this.handleError<Assessment>('deleteAvaliacao'))
    );
  }

  getEstoque (id: number): Observable<Inventory[]> {
    this.montaHeaderToken();
    console.log(httpOptions.headers);
    const url = `${inventoryUrl}/GetByProductId/${id}`;
    return this.http.get<Inventory[]>(url, httpOptions)
      .pipe(
        tap(Inventory => console.log('leu o inventario')),
        catchError(this.handleError('getEstoque', []))
      );
  }
  getEstoqu(id: number): Observable<InventoryContainer> {
    const url = `${inventoryUrl}/GetByProductId/${id}`;
    return this.http.get<InventoryContainer>(url, httpOptions).pipe(
      tap(_ => console.log(`leu o inventario id=${id}`)),
      catchError(this.handleError<InventoryContainer>(`getEstoque id=${id}`))
    );
  }

  addEstoque(Inventory:Inventory): Observable<Inventory> {
    this.montaHeaderToken();
    return this.http.post<Inventory>(inventoryUrl, Inventory, httpOptions).pipe(
      tap((Inventory: Inventory) => console.log(`adicionou um estoque `)),
      catchError(this.handleError<Inventory>('addEstoque'))
    );
  }

  updateEstoque(id = Number, Inventory:Inventory): Observable<any> {
    const url = `${inventoryUrl}/${id}`;
    return this.http.put(url, Inventory, httpOptions).pipe(
      tap(_ => console.log(`atualiza Estoque com id=${id}`)),
      catchError(this.handleError<any>('updateEstoque'))
    );
  }

  deleteEstoque (id:number): Observable<Inventory> {
    const url = `${inventoryUrl}/${id}`;
    return this.http.delete<Inventory>(url, httpOptions).pipe(
      tap(_ => console.log(`remove um Estoque com id=${id}`)),
      catchError(this.handleError<Inventory>('deleteEstoque'))
    );
  }
}
