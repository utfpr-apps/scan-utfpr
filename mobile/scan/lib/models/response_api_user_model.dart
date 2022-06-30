import 'dart:convert';

class ResponseAPIUserModel {
  String? id;
  UserDataViewModel? userDataViewModel;

  ResponseAPIUserModel({this.id, this.userDataViewModel});

 

  Map<String, dynamic> toMap() {
    final result = <String, dynamic>{};
  
    if(id != null){
      result.addAll({'id': id});
    }
    if(userDataViewModel != null){
      result.addAll({'userDataViewModel': userDataViewModel!.toMap()});
    }
  
    return result;
  }

  factory ResponseAPIUserModel.fromMap(Map<String, dynamic> map) {
    return ResponseAPIUserModel(
      id: map['id'],
      userDataViewModel: map['userDataViewModel'] != null ? UserDataViewModel.fromMap(map['userDataViewModel']) : null,
    );
  }

  String toJson() => json.encode(toMap());

  factory ResponseAPIUserModel.fromJson(String source) => ResponseAPIUserModel.fromMap(json.decode(source));
}

class UserDataViewModel {
  String? id;
  String? token;
  String? urlFoto;
  String? nome;

  UserDataViewModel({this.id, this.token, this.urlFoto, this.nome});


  Map<String, dynamic> toMap() {
    final result = <String, dynamic>{};
  
    if(id != null){
      result.addAll({'id': id});
    }
    if(token != null){
      result.addAll({'token': token});
    }
    if(urlFoto != null){
      result.addAll({'urlFoto': urlFoto});
    }
    if(nome != null){
      result.addAll({'nome': nome});
    }
  
    return result;
  }

  factory UserDataViewModel.fromMap(Map<String, dynamic> map) {
    return UserDataViewModel(
      id: map['id'],
      token: map['token'],
      urlFoto: map['urlFoto'],
      nome: map['nome'],
    );
  }

  String toJson() => json.encode(toMap());

  factory UserDataViewModel.fromJson(String source) => UserDataViewModel.fromMap(json.decode(source));
}
