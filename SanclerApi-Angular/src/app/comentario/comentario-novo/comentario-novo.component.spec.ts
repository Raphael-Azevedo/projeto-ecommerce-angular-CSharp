import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComentarioNovoComponent } from './comentario-novo.component';

describe('ComentarioNovoComponent', () => {
  let component: ComentarioNovoComponent;
  let fixture: ComponentFixture<ComentarioNovoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ComentarioNovoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ComentarioNovoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
