import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CategoriasComponent } from './components/categorias/categorias.component';
import { SobreComponent } from './components/sobre/sobre.component';
import { HomeComponent } from './components/home/home.component';
import { ContatoComponent } from './components/contato/contato.component';
import { AdmComponent } from './adm/adm.component'
import { ProdutosComponent } from './produtos/produtos.component';
import { ProdutoNovoComponent } from './produto-novo/produto-novo.component';
import { ProdutoEditarComponent} from './produto-editar/produto-editar.component'
import { ProdutoDetalheComponent } from './produto-detalhe/produto-detalhe.component';
import { ComentariosComponent } from './comentario/comentarios/comentarios.component';
import { ComentarioEditarComponent } from './comentario/comentario-editar/comentario-editar.component';
import { ComentarioNovoComponent } from './comentario/comentario-novo/comentario-novo.component';
import { InventarioComponent } from './inventario/inventario/inventario.component';
import { InventarioNovoComponent } from './inventario/inventario-novo/inventario-novo.component';
import { InventarioEditarComponent } from './inventario/inventario-editar/inventario-editar.component';
import { AvaliacoesComponent } from './avaliacao/avaliacoes/avaliacoes.component';
import { AvaliacaoNovoComponent } from './avaliacao/avaliacao-novo/avaliacao-novo.component';
import { AvaliacaoEditarComponent } from './avaliacao/avaliacao-editar/avaliacao-editar.component';
import { LogoutComponent } from './logout/logout.component';

const routes: Routes = [
  {
    path:'produtos',
    component: CategoriasComponent,
    data: { title: 'Lista de Categorias'}
  },
  {
    path:'sobre',
    component: SobreComponent,
    data: { title: 'Sobre nós'}
  },
  {
    path:'',
    component: HomeComponent,
    data: { title: 'Home'}
  },
  {
    path:'contato',
    component: ContatoComponent,
    data: { title: 'Contato'}
  },
  {
    path:'adm',
    component: AdmComponent,
    data: { title: 'Painel adm'}
  },
  {
    path:'adm/produtos',
    component: ProdutosComponent,
    data: { title: 'Painel adm'}
  },
  {
    path:'adm/novoproduto',
    component: ProdutoNovoComponent,
    data: { title: 'Painel adm'}
  },
  {
    path: 'produto/:id',
    component: ProdutoEditarComponent,
    data: { title: 'Editar um produto' }
  },
  {
    path: 'produto/detail/:id',
    component: ProdutoDetalheComponent ,
    data: { title: 'Produto' }
  },
  {
    path:'adm/comentario/:id',
    component: ComentariosComponent,
    data: { title: 'Painel adm'}
  },
  {
    path:'adm/novocomentario',
    component: ComentarioNovoComponent,
    data: { title: 'criar comentario'}
  },
  {
    path: 'comentario/:id',
    component: ComentarioEditarComponent,
    data: { title: 'Editar um comentário' }
  },
  {
    path:'adm/inventario/:id',
    component: InventarioComponent,
    data: { title: 'Painel adm'}
  },
  {
    path:'adm/novoinventario',
    component: InventarioNovoComponent,
    data: { title: 'criar inventário'}
  },
  {
    path: 'inventario/:id',
    component: InventarioEditarComponent,
    data: { title: 'Editar um inventário' }
  },
  {
    path:'adm/avaliacao/:id',
    component: AvaliacoesComponent,
    data: { title: 'Painel adm'}
  },
  {
    path:'adm/novaavaliacao',
    component: AvaliacaoNovoComponent,
    data: { title: 'criar avaliacao'}
  },
  {
    path: 'avaliacao/:id',
    component: AvaliacaoEditarComponent,
    data: { title: 'Editar uma avaliacao' }
  },
  {
  path:'logout',
  component: LogoutComponent,
  data: { title: 'Logout'}
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
